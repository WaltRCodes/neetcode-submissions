// Definition of a Trie node
public class TrieNode {
    public TrieNode[] children = new TrieNode[26]; // Array for 26 lowercase letters
    public bool word = false; // Marks if a complete word ends at this node
}

// WordDictionary class supporting addWord and search with '.' wildcard
public class WordDictionary {

    private TrieNode root;

    public WordDictionary() {
        root = new TrieNode(); // Initialize root node
    }
    
    // Adds a word into the Trie
    public void AddWord(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            int idx = c - 'a';
            if (cur.children[idx] == null) {
                cur.children[idx] = new TrieNode(); // Create a new node if it doesn't exist
            }
            cur = cur.children[idx]; // Move to child node
        }
        cur.word = true; // Mark the end of the word
    }
    
    // Searches for a word in the Trie (supports '.' as any character)
    public bool Search(string word) {
        return Dfs(word, 0, root);
    }

    // Helper DFS function to handle '.' wildcard
    private bool Dfs(string word, int j, TrieNode root) {
        TrieNode cur = root;

        for(int i = j; i < word.Length; i++) {
            char c = word[i];
            if (c == '.') {
                // If '.', try all possible child nodes
                foreach (TrieNode child in cur.children) {
                    if (child != null && Dfs(word, i + 1, child)) {
                        return true;
                    }
                }
                return false; // None matched
            } else {
                int idx = c - 'a';
                if (cur.children[idx] == null) {
                    return false; // Path doesn't exist
                }
                cur = cur.children[idx]; // Move to child node
            }
        }

        return cur.word; // Check if current node marks end of a valid word
    }
}
