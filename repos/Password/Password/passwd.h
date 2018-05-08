#pragma once
#include<string.h>
#include<math.h>
#include<iostream>
using namespace std;

//按位取反
char ContraryPsw(char psw)
{
	int Temporary = (char)~(psw);
	Temporary %= 94;
	Temporary += 33;
	return (char)Temporary;
}

//倒序密码
char ReversePsw(char psw)
{
	int Temporary = 0;
	int PswTem = psw;
	PswTem -= 23;
	for (int i = 0; i < 7; i++)
	{
		Temporary *= 2;
		Temporary += PswTem % 2;
		PswTem /= 2;
	}
	Temporary %= 94;
	Temporary += 32;
	return (char)Temporary;
}

//奇数位异或操作
char OddNumberPsw(char psw)
{
	int Temporary_a = psw;
	for (int i = 0; i < 6; i += 2)
	{
		int Temporary = 1;
		Temporary <<= i;
		Temporary &= Temporary_a;
		Temporary <<= 2;
		Temporary_a ^= Temporary;
	}
	Temporary_a %= 94;
	Temporary_a += 32;


	return (char)Temporary_a;
}

//偶数位异或操作
char EvenNumberpsw(char psw)
{
	int Temporary_a = psw;
	for (int i = 1; i < 6; i += 2)
	{
		int Temporary = 1;
		Temporary <<= i;
		Temporary &= Temporary_a;
		Temporary <<= 2;
		Temporary_a ^= Temporary;
	}
	Temporary_a %= 94;
	Temporary_a += 33;


	return (char)Temporary_a;
}

// 指定换位操作
char RotationPws(int Rot_as, int Rot_bs, int Rot_cs, char psw)
{
	int Rot_a = Rot_as % 7;
	int Rot_b = Rot_bs % 7;
	int Rot_c = Rot_cs % 7;
	bool TemporaryBoolArray[7];
	int Temporary = psw;
	for (int i = 0; i < 7; i++)
	{
		if (Temporary % 2 == 1)
		{
			TemporaryBoolArray[i] = true;
		}
		else
		{
			TemporaryBoolArray[i] = false;
		}
		Temporary /= 2;
	}
	bool ChangeTem = TemporaryBoolArray[Rot_a];
	TemporaryBoolArray[Rot_a] = TemporaryBoolArray[Rot_c];
	TemporaryBoolArray[Rot_c] = TemporaryBoolArray[Rot_b];
	TemporaryBoolArray[Rot_b] = ChangeTem;

	Temporary = 0;
	for (int i = 0; i < 7; i++)
	{
		double Tem = 0;
		if (TemporaryBoolArray[i])
		{
			Tem += pow(2, i);
			Temporary += (int)Tem;
		}
	}
	Temporary %= 94;
	Temporary += 32;
	return (char)Temporary;
}

//变长字符串
void SubStringPsw(char* psw, int HKey, int OddOREvent)
{
	int SubStartNum = 255 % HKey;
	if (OddOREvent % 2 == 1)
	{
		while (SubStartNum + OddOREvent + 1 < 255)
		{
			OddOREvent += 1;
			SubStartNum += OddOREvent;
			for (int i = SubStartNum; i < 254; i++)
			{
				psw[i] = psw[i + 1];
			}
			psw[254] = (char)32;
		}
	}
	else
	{
		while (SubStartNum + OddOREvent + 1 < 255)
		{
			OddOREvent += 2;
			SubStartNum += OddOREvent;
			for (int i = SubStartNum; i < 254; i++)
			{
				psw[i] = psw[i + 1];
			}
			psw[254] = (char)32;
		}
	} 
}

//
char* PswStringCreate(char* OriginallyPsw, char* PswParameters)
{
	//生成密码
	char* Psw = NULL;
	//生成参数数组

	int Param[7];
	for (int i = 0; i < strlen(PswParameters); i++)
	{
		Param[i] = (int)PswParameters[i];
	}

	//原密码数组
	

	for (int item = 0; item < strlen(OriginallyPsw); item++)
	{
		//按位取反
		if (Param[0] % 2 == 1)
		{
			OriginallyPsw[item] = ContraryPsw(OriginallyPsw[item]);
		}
		//倒序
		else
		{
			OriginallyPsw[item] = ReversePsw(OriginallyPsw[item]);

		}
		//奇偶位异或
		if (Param[1] % 2 == 1)
		{
			OriginallyPsw[item] = OddNumberPsw(OriginallyPsw[item]);
		}
		else
		{
			OriginallyPsw[item] = EvenNumberpsw(OriginallyPsw[item]);
		}
		OriginallyPsw[item] = RotationPws(Param[2], Param[3], Param[4], OriginallyPsw[item]);
	}
	SubStringPsw(OriginallyPsw, Param[5], Param[6]);

	for (int i = 0; OriginallyPsw[i] != 32; i++)
	{
		Psw += OriginallyPsw[i];
	}
	//cout << strlen(OriginallyPsw);
	return Psw;
}


