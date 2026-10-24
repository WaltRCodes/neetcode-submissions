class Solution {
public:
    int countPaths(vector<vector<int>>& grid) {
        int ROWS = grid.size(), COLS = grid[0].size();
        set<string> visit;
        return helper(grid, 0, 0, visit);
    }
private:
int helper(vector<vector<int>>&grid, int r, int c, set<string>&visit) {
    if(min(r,c) < 0 || r == grid.size() || c == grid[0].size() || visit.find(to_string(r) + "," + to_string(c)) != visit.end() || grid[r][c] == 1) {
        return 0;
    }
    if (r == grid.size() - 1 && c == grid[0].size() - 1) {
        return 1;
    }

    visit.insert(to_string(r) + "," + to_string(c));

    int count = 0;
    count += helper(grid, r + 1, c, visit);
    count += helper(grid, r - 1, c, visit);
    count += helper(grid, r, c + 1, visit);
    count += helper(grid, r, c - 1, visit);

    visit.erase(to_string(r) + "," + to_string(c));
    return count;
}
};
