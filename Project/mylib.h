//
// Created by ����� on 2019-11-12.
//
#include <stdio.h>
#include "List.h"
#include <string.h>
#include <ctype.h>
#include <stdlib.h>

#ifndef KURSOVAYA_MYLIB_H
#define KURSOVAYA_MYLIB_H
typedef unsigned char BOOL;

#define TRUE 1
#define FALSE 0

static const STR_LEN = 1024;



/// ������� toLowString
/// \param result         - ����������, ���� ����� ������� ���������
/// \param string         - ����������, ������ ������� ������ (��������)
/// \return               - ���������� ��������� �� ������ � ��������� ������� ��������
char* toLowString(char* result, char* string);

/// ������� toLowRegistr
/// \param ch             - �������� ������
/// \return               - ���������� ������, �������������� � ������ �������
char toLowRegistr(char ch);

/// ������� findWordsByLen
/// \param mylist         - ������, ������� ������������� ��������� �� ������ ���� ������ �����
/// \param buff           - ������, ������ ������������ ���������� ������
/// \param len            - ������ ����� �����
/// \return
int findWordsByLen(MyList* mylist, char* buff);

#endif //KURSOVAYA_MYLIB_H
