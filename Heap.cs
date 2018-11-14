public class Heap
{
        // Implement Heap class/constructor
        // type: argument should be either 'min' or 'max'. This will dictate whether the heap will be a minheap or maxheap.

        List<int> storage;
        string type;

        public Heap(string type)
        {
            this.storage = new List<int>();
            this.type = type;
        }

        public bool compare(int a, int b)
        {
            return (type == "min") ? a < b : a > b;
        }

        public void swap(int index1, int index2)
        {
            int temp = storage[index1];
            storage[index1] = storage[index2];
            storage[index2] = temp;
        }

        public int peak()
        {
            return storage[0];
        }

        public int size()
        {
            return storage.Count;
        }

        public void insert(int value)
        {
            storage.Add(value);
            bubbleUp(storage.Count - 1);
        }

        public void bubbleUp(int index)
        {
            int parent = (index - 1) / 2;
            while (index > 0 && compare(storage[index], storage[parent]))
            {
                swap(index, parent);
                index = parent;
                parent = (index - 1) / 2;
            }
        }
        
        public int removePeak()
        {
            int peak = storage[0];
            bubbleDown(0);
            return peak;
        }

        public void bubbleDown(int index)
        {
            int child = getChild(0);
            while (child > 0 && compare(storage[index], storage[child]))
            {
                swap(index, child);
                index = child;
                child = getChild(index);
            }
        }
        
        public bool remove(int value)
        {
            for (int i = 0; i < size(); i++)
            {
                if (storage[i] == value)
                {
                    swap(i, size() - 1);
                    storage.RemoveAt(size() - 1);
                    bubbleUp(i);
                    bubbleDown(i);
                    return true;
                }
            }
            return false;
        }

        private int getChild(int parent)
        {
            int left = parent * 2 + 1;
            if (left >= size() - 1 || storage[left] >= storage[left + 1])
            {
                return left;
            }
            return left + 1;
        }
    }
