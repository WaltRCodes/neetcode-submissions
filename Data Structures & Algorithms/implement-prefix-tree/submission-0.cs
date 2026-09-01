public class TrieNode {
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public bool endOfWord = false;
}

public class PrefixTree {
    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
        
    }
    
    public void Insert(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            if (!cur.children.ContainsKey(c)) {
                cur.children[c] = new TrieNode();
            }
            cur = cur.children[c];
        }
        cur.endOfWord = true;
        
    }
    
    public bool Search(string word) {
        TrieNode cur = root;
        foreach(char c in word) {
            if (!cur.children.ContainsKey(c)) {
                return false;
            }
            cur = cur.children[c];
        }
        return cur.endOfWord;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode cur = root;
        foreach (char c in prefix) {
            if (!cur.children.ContainsKey(c)) {
                return false;
            }
            cur = cur.children[c];
        }
        return true;
    }
}
