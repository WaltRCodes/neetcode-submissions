public class TimeMap {
    private Dictionary<string, List<Tuple<int, string>>> keyStore;

    public TimeMap() {
        keyStore = new Dictionary<string, List<Tuple<int,string>>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!keyStore.ContainsKey(key)){
            keyStore[key] = new List<Tuple<int,string>>();
        }
        keyStore[key].Add(Tuple.Create(timestamp,value));
    }
    
    public string Get(string key, int timestamp) {
        if (!keyStore.ContainsKey(key)){
            return "";
        }

        var values = keyStore[key];
        int left = 0, right = values.Count - 1;
        string result = "";

        while (left <= right){
            int mid = left + (right - left) / 2;
            if (values[mid].Item1 <= timestamp){
                result = values[mid].Item2;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return result;
    }
}
