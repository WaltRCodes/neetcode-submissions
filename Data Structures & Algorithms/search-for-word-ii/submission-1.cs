// TrieNode class to store words and references
class TrieNode {
    public TrieNode[] children = new TrieNode[26]; // 26 lowercase letters
    public int idx = -1; // index of word in words array, -1 if not a word
    public int refs = 0; // number of words passing through this node

    // Adds a word to the Trie
    public void AddWord(string word, int i) {
        TrieNode cur = this;
        cur.refs++; // increment reference count
        foreach (char c in word) {
            int index = c - 'a';
            if (cur.children[index] == null) {
                cur.children[index] = new TrieNode();
            }
            cur = cur.children[index];
            cur.refs++; // increment reference count for each node in the path
        }
        cur.idx = i; // mark the end of the word
    }
}

public class Solution {
    private List<string> res = new List<string>();

    public List<string> FindWords(char[][] board, string[] words) {
        // Build the Trie from the list of words
        TrieNode root = new TrieNode();
        for (int i = 0; i < words.Length; i++) {
            root.AddWord(words[i], i);
        }

        // Perform DFS from each cell in the board
        for (int r = 0; r < board.Length; r++) {
            for (int c = 0; c < board[0].Length; c++) {
                Dfs(board, root, r, c, words);
            }
        }
        return res;
    }

    private void Dfs(char[][] board, TrieNode node, int r, int c, string[] words) {
        // Boundary checks and visited checks
        if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length || 
            board[r][c] == '*' || node.children[board[r][c] - 'a'] == null) {
            return;
        }

        char temp = board[r][c];
        board[r][c] = '*'; // mark as visited
        TrieNode prev = node;
        node = node.children[temp - 'a'];

        // Check if a word is found
        if (node.idx != -1) {
            res.Add(words[node.idx]); // add word to result
            node.idx = -1;            // avoid duplicates
            node.refs--;              // decrement reference count
            if (node.refs == 0) {     // prune the Trie if no word passes through
                prev.children[temp - 'a'] = null;
                board[r][c] = temp;
                return;
            }
        }

        // Explore 4 directions
        Dfs(board, node, r + 1, c, words);
        Dfs(board, node, r - 1, c, words);
        Dfs(board, node, r, c + 1, words);
        Dfs(board, node, r, c - 1, words);

        board[r][c] = temp; // backtrack
    }
}
