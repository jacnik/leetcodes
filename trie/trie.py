r"""
A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

Implement the Trie class:

Trie() Initializes the trie object.
void insert(String word) Inserts the string word into the trie.
boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.


Example 1:

Input
["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
Output
[null, null, true, false, true, null, true]

Explanation
Trie trie = new Trie();
trie.insert("apple");
trie.search("apple");   // return True
trie.search("app");     // return False
trie.startsWith("app"); // return True
trie.insert("app");
trie.search("app");     // return True


Constraints:

1 <= word.length, prefix.length <= 2000
word and prefix consist only of lowercase English letters.
At most 3 * 104 calls in total will be made to insert, search, and startsWith.
"""

class Trie:
    """recursive trie implementation"""
    def __init__(self):
        self.subtries: list[Trie | None] = [None] * (ord('z') - ord('a') + 1)
        self.is_last = False

    def insert(self, word: str) -> None:
        """insert new word"""
        if not word:
            return
        ci = self.char_idx(word[0])
        if not self.subtries[ci]:
            self.subtries[ci] = Trie()
        if len(word) == 1: # last char
            self.subtries[ci].is_last = True
        self.subtries[ci].insert(word[1:])

    def search(self, word: str) -> bool:
        """search for whole word"""
        if not word:
            return True
        ci = self.char_idx(word[0])
        if not self.subtries[ci]:
            return False
        if len(word) == 1: # last char
            return self.subtries[ci].is_last
        return self.subtries[ci].search(word[1:])

    def startsWith(self, prefix: str) -> bool:
        """search for word prefix"""
        if not prefix:
            return True
        ci = self.char_idx(prefix[0])
        if not self.subtries[ci]:
            return False
        return self.subtries[ci].startsWith(prefix[1:])

    @staticmethod
    def char_idx(c: str) -> int:
        """Get index of character into chars array 'a' = 0 ... 'z' = 26"""
        return ord(c) - ord('a')


trie = Trie()
trie.insert("apple")
print(trie.search("apple"))   # return True
print(trie.search("app") is False)     # return False
print(trie.startsWith("app")) # return True
trie.insert("app")
print(trie.search("app"))     # return True

