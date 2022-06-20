/*
* 1. BFS: Program to print the node values of a Breadth First Search of a Binary Tree?
*/

#include "Bfs.h"

//BFS Traversal with the Queue as the key Data Structure to maintain order across each level
void Bfs::bfs(Node^ root, int depth, Queue^ queue, Dictionary<int, List<Node^>^>^ associativeDict)
{
	//if at root level, the base case for recursion
	if (depth == 0) {
		root->depth = depth;
		queue->Enqueue(root); //visit the root!
	}
	//if visited nodes are there...
	if (queue->Count > 0) {
		Node^ node = (Node^)queue->Dequeue(); //pull out the nodes from the FIFO list of visits
		if (node != nullptr) {
			if (associativeDict->ContainsKey(node->depth)) {
				//Update the map of list of nodes from left->right at a particular level if it was visited already!
				associativeDict[node->depth]->Add(node);
			}
			else {
				List<Node^>^ nodes = gcnew List<Node^>();
				//Keep on Accumulating the nodes at a particular level
				nodes->Add(node);
				//Add the nodes at a particular level to the map if it doesn't have the key for the level!
				associativeDict->Add(node->depth, nodes);
			}
			if ((node->left != nullptr || node->right != nullptr || node->left == nullptr || node->right == nullptr) ) { //&& depth <= this->maxDepth) {
				depth++; //traverse to the next level down
				//capture left node first if it exists
				if (node->left != nullptr) {
					node->left->depth = node->left->parent->depth + 1;
					queue->Enqueue(node->left);
				}
				//capture right node after the left if it exists
				if (node->right != nullptr) {
					node->right->depth = node->right->parent->depth + 1;
					queue->Enqueue(node->right);
				}
			}
		}
		//recurse after the visit of the nodes at the current level
		bfs(root, depth, queue, associativeDict);
	}
}

//Call the driver method to perform BFS starting from the Root Node
void Bfs::bfsPostProcessing(Node^ root, int depth, Queue^ queue, Dictionary<int, List<Node^>^>^ associativeDict)
{
	bfs(root, 0, queue, associativeDict);
	this->associativeDict = associativeDict;
}
