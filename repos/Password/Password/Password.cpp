// Password.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<stdio.h>
#include<string.h>
#include<iostream>
#include<Windows.h>
#include"passwd.h"
using namespace std;
int main()
{
	char parr[] = "aersfdgyxbcgvyfgetxcdfbrtdgfbcgyuidknshfbcgdectxuiosmjdhfvzaqplkdhgcbxgdbftesvxchsdydfgdbcjmfhdbdnchcuekwnxhfbdgdyehdnfhdjdhsyekljcokndoabvihfadbpihvojasdfbnvojndwojvbndfjbnvijafbvnojwdhvhjwhvjdwjhfvpbeihvbowehvojnewopjncpejmckpnowencvpknmwepkcmpewkjfwemc";
	//cout << strlen(parr);
	for (int i = 0; i < strlen(parr); i++)
	{
		cout << parr[i];
	}
	cout << endl;
	char ps[] = "1975493";
	SubStringPsw(parr,2,1);
for (int i = 0; i < strlen(parr); i++)
	{
		cout << parr[i];
	}
	system("pause");
	return 0;
}

