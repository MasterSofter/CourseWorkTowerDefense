
#ifndef KURSOVAYA__H
#define KURSOVAYA__H

#include <stdlib.h>
#include <mm_malloc.h>
#include <string.h>
#include <errno.h>
#include <stdio.h>

typedef struct MyList
{
    unsigned char wordlen;    // длина слова в символах
    size_t size;              // размер массива в байтах
    unsigned short capacity;  // емкость массива в словах
    unsigned int countWords;  // текущее кол-во слов в массиве
    char* data;

} MyList;

int listInit(MyList* list, unsigned short capacity, unsigned char wordlen);

void listShow(const MyList* list);

void listClear(MyList* list);

int listAdd(MyList *myList, const char* word);



#endif //KURSOVAYA__H
