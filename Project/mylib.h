//
// Created by Павел on 2019-11-12.
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



/// Функция toLowString
/// \param result         - переменная, куда будет записан результат
/// \param string         - переменная, откуда берется строка (источник)
/// \return               - возвращает указатель на строку с символами нижнего регистра
char* toLowString(char* result, char* string);

/// Функция toLowRegistr
/// \param ch             - исходный символ
/// \return               - возвращает символ, преобразованый в нижний регистр
char toLowRegistr(char ch);

/// Функция findWordsByLen
/// \param mylist         - список, который заполненяется позициями на начала слов нужной длины
/// \param buff           - буффер, откуда производится считывание данных
/// \param len            - нужная длина слова
/// \return
int findWordsByLen(MyList* mylist, char* buff);

#endif //KURSOVAYA_MYLIB_H
