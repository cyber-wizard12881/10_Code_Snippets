/*
* 1. Edit Distance:The edit distance between two words is the minimum number of
	 single-character edits (insertions, deletions or substitutions) required
	 to change one word into the other.
	 Example: Tuesday -> Wednesday is 4.
	 Also, known as Levenshtein Distance write a Program to Compute & Print
	 all the steps for the translation of the source word to the target one?
*/

#include <iostream>
#include <cstring>
#include <list>
#include <map>
#include <sstream>
#include <stack>

using namespace std;

//Compute the minimum of 3 integers
int min(int len1, int len2, int len3) {
	if (len1 < len2) {
		if (len1 < len3)
		{
			return len1;
		}
		return len3;
	}
	else {
		if (len2 < len3)
		{
			return len2;
		}
		return len3;
	}
}

//structure to store the Steps of Levenshtein Distance
struct step {
	string from;
	string to;
	string value;
};

//Integer to String converter
string itos(int i) {
	std::ostringstream ss;
	ss << i;
	return ss.str();
}

//Character to String converter
string ctos(char c) {
	std::ostringstream ss;
	ss << c;
	return ss.str();
}

//Fetch the steps from 'to' in Memoized Table via Backtracking in D.P. using a Map.
step get_value(map<string, step> m, string to) {
	map<string, step>::iterator i = m.find(to);
	if (i != m.end()) {
		step value = i->second;
		return value;
	}
	return step();
}

//The Levenshtein Distance Computation Function
int levenshtein(string source, string target) {
	int s = source.size();
	int t = target.size();

	//Allocate the memoized table for DP
	int** ld = new int* [t + 1];
	for (int idx = 0; idx <= t; idx++)
		ld[idx] = new int[s + 1];

	//Prefill the table with zeroes
	for (int m = 0; m <= t; m++)
		for (int n = 0; n <= s; n++)
			ld[m][n] = 0;

	//Data Structures to capture the actions for LD
	map<string, step> actions;
	string key;
	string value;

	//If Source is there but Target isn't
	for (int j = 1; j <= s; j++)
	{
		ld[0][j] = j;
		step s;
		s.from = itos(0) + "," + itos(j - 1);
		s.to = itos(0) + "," + itos(j);
		s.value = "Delete " + ctos(source[j - 1]);
		actions.insert({ s.to, s });
	}

	//If Target is there but Source isn't
	for (int i = 1; i <= t; i++)
	{
		ld[i][0] = i;
		step s;
		s.from = itos(i - 1) + "," + itos(0);
		s.to = itos(i) + "," + itos(0);
		s.value = "Insert " + ctos(target[i - 1]);
		actions.insert({ s.to, s });
	}

	//Substitution Cost
	int cost = 0;

	//The Actual Algorithm
	for (int n = 1; n <= t; n++)
		for (int m = 1; m <= s; m++) {
			step s;
			if (source[m - 1] == target[n - 1])//Do nothing as the letters match
				cost = 0;
			else //Simple Substitution of one letter for the other
				cost = 1;

			int del = ld[n][m - 1] + 1; //tail of source & full target => deletion operation
			int ins = ld[n - 1][m] + 1; //tail of target & full source => insertion operation
			int sub = ld[n - 1][m - 1] + cost; //tail of source & tail of target => substitution or do nothing

			ld[n][m] = min(ins, del, sub); //find the minimum length

			if (ld[n][m] == ins) { //if inserts
				s.from = itos(n - 1) + "," + itos(m); //backtracking from prev. step.
				s.value = "Insert " + ctos(target[n - 1]); //action taken
			}
			else if (ld[n][m] == del) { //if deletes
				s.from = itos(n) + "," + itos(m - 1); //backtracking from prev. step.
				s.value = "Delete " + ctos(source[m - 1]); //action taken
			}
			else if (ld[n][m] == sub) { //if substitutions
				if (cost == 1) {
					string tmp = "Substitute " + ctos(source[m - 1]); //action taken
					s.value = tmp + " for " + ctos(target[n - 1]); //action taken contd.
				}
				else
				{
					string tmp = "Do Nothing " + ctos(source[m - 1]); //action taken
					s.value = tmp + " for " + ctos(target[n - 1]); //action taken contd.
				}
				s.from = itos(n - 1)  + "," + itos(m - 1); //backtracking from prev. step.
			}
			s.to = itos(n) + "," + itos(m); //going to next step.
			actions.insert({ s.to, s }); //make entries into a map
		}

	cout << "To Convert '" << source << "' to '" << target << "'";
	cout << " do the following steps .... " << endl;

	//Data Structures to print the sequence of steps via backtracking
	stack<string> steps;
	step action;
	action = get_value(actions, itos(t) + "," + itos(s)); //get the last point
	steps.push(action.value); //capture the action
	do {
		action = get_value(actions, action.from); //fetch the action
		steps.push(action.value); //capture the action
	} while (action.from != itos(0) + "," + itos(0)); //while we hit the beginning

	while (!steps.empty()) {
		cout << steps.top()<<endl;//finally, print the steps in actual chronological order
		steps.pop();
	}

	return ld[t][s]; //return the levenshtein distance value!
}

//Entry Point for the Program
int main()
{
	//Driver function to print the Levenshtein Steps
	int ld = levenshtein("Tuesday", "Wednesday");
	//Printing the Levenshtein Distance itself
	cout << "\nlevenshtein distance is " << ld << endl;
}
