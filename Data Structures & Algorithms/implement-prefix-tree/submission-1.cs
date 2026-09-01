// Definition of a Trie node
public class TrieNode {
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>(); // Stores child nodes
    public bool endOfWord = false; // Marks if a word ends at this node
}

// Prefix Tree (Trie) class
public class PrefixTree {
    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode(); // Initialize root node
    }
    
    // Inserts a word into the Trie
    public void Insert(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            // If character is not present, create a new node
            if (!cur.children.ContainsKey(c)) {
                cur.children[c] = new TrieNode();
            }
            cur = cur.children[c]; // Move to the child node
        }
        cur.endOfWord = true; // Mark the end of the word
    }
    
    // Searches for a complete word in the Trie
    public bool Search(string word) {
        TrieNode cur = root;
        foreach(char c in word) {
            if (!cur.children.ContainsKey(c)) {
                return false; // Character path not found
            }
            cur = cur.children[c]; // Move to child node
        }
        return cur.endOfWord; // Return true if it is the end of a word
    }
    
    // Checks if there is any word in the Trie that starts with the given prefix
    public bool StartsWith(string prefix) {
        TrieNode cur = root;
        foreach (char c in prefix) {
            if (!cur.children.ContainsKey(c)) {
                return false; // Prefix path not found
            }
            cur = cur.children[c]; // Move to child node
        }
        return true; // Prefix exists
    }
}
