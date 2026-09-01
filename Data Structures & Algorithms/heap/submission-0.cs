public class MinHeap {
    private List<int> heap;

    public MinHeap() {
        this.heap = new List<int>();
        this.heap.Add(0);
    }

    public void Push(int val) {
        heap.Add(val);
        BubbleUp(heap.Count - 1);
    }

    public int? Pop() {
        if (heap.Count <= 1) return -1;
        if (heap.Count == 2) {
            int val = heap[1];
            heap.RemoveAt(1);
            return val;
        }

        int root = heap[1];
        heap[1] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        if (heap.Count > 1) {
            BubbleDown(1);
        }
        return root;
    }

    public int? Top() {
        return heap.Count > 1 ? heap[1] : -1;
    }

    public void Heapify(List<int> nums) {
        this.heap = new List<int>();
        this.heap.Add(0);
        this.heap.AddRange(nums);
        for (int i = heap.Count / 2; i >= 1; i--){
            BubbleDown(i);
        }
    }

    public void BubbleUp(int index) {
        int parent = index / 2;
        while (index > 1 && heap[parent] > heap[index]) {
            Swap(index, parent);
            index = parent;
            parent = index / 2;
        }
    }

    public void BubbleDown(int index) {
        int child = 2 * index;
        while (child < heap.Count) {
            if (child + 1 < heap.Count && heap[child] > heap[child + 1]) {
                child++;
            }
        
        if (heap[child] >= heap[index]) break;

        Swap(child, index);
        index = child;
        child = 2*index;
        }
    }
    private void Swap(int i, int j) {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

}