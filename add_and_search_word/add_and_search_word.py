r"""
Design a data structure that supports adding new words and finding if a string matches any previously added string.

Implement the WordDictionary class:

WordDictionary() Initializes the object.
void addWord(word) Adds word to the data structure, it can be matched later.
bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.


Example:

Input
["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
Output
[null,null,null,null,false,true,true,true]

Explanation
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("bad");
wordDictionary.addWord("dad");
wordDictionary.addWord("mad");
wordDictionary.search("pad"); // return False
wordDictionary.search("bad"); // return True
wordDictionary.search(".ad"); // return True
wordDictionary.search("b.."); // return True


Constraints:

1 <= word.length <= 25
word in addWord consists of lowercase English letters.
word in search consist of '.' or lowercase English letters.
There will be at most 2 dots in word for search queries.
At most 104 calls will be made to addWord and search.
"""



class WordDictionary:
    """Word dictionary implementation using nested dicitonaries"""

    def __init__(self):
        self.root = self.Node()
        self.root.is_word_end = True

    def addWord(self, word: str) -> None:
        """Add word"""
        curr_node = self.root
        for c in word:
            next_node = curr_node.subnodes.get(c, self.Node())
            curr_node.subnodes[c] = next_node
            curr_node = next_node
        curr_node.is_word_end = True

    def search(self, word: str) -> bool:
        """Search for word"""
        curr_nodes = [self.root]
        for c in word:
            if c == '.':
                next_nodes = []
                for subnodes in (n.subnodes.values() for n in curr_nodes):
                    for n in subnodes:
                        next_nodes.append(n)
                curr_nodes = next_nodes
            else:
                next_nodes = []
                for n in (n for n in curr_nodes):
                    if subnode := n.subnodes.get(c, None):
                        next_nodes.append(subnode)

                curr_nodes = next_nodes

            if not curr_nodes:
                return False

        return any(n.is_word_end for n in curr_nodes)

    class Node:
        """Subnode definition"""
        def __init__(self):
            self.subnodes: dict[str, 'Node'] = {}
            self.is_word_end = False


wordDictionary = WordDictionary()
wordDictionary.addWord("bad")
wordDictionary.addWord("dad")
wordDictionary.addWord("mad")
print(wordDictionary.search("pad") is False) # return False
print(wordDictionary.search("bad")) # return True
print(wordDictionary.search(".ad")) # return True
print(wordDictionary.search("b..")) # return True

wordDictionary.addWord("adaminow")
wordDictionary.addWord("adaminzp")

print(wordDictionary.search("adam.now")) # return False
