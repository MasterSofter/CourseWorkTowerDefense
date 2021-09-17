//
// Created by Павел on 2019-11-15.
//
#include "List.h"
#include <assert.h>

int listInit(MyList* list, unsigned short capacity, unsigned char wordlen)
{
    assert(list != NULL);

    int buflen = (wordlen + 1) * capacity;
    list->data = (char*) malloc(buflen);

    if(list->data == NULL)
        return -5;

    list->size = buflen;
    list->wordlen = wordlen;
    list->capacity = capacity;
    list->countWords = 0;

    return 0;
}

void listShow(const MyList* list)
{
    assert(list != NULL);

    for(int i = 0; i < list->countWords; i ++)
        printf("%s ", list->data + i * (list->wordlen + 1));
}

void listClear(MyList* list)
{
    assert(list != NULL);

    if(list != NULL)
    {
        free(list->data);
        list->data = NULL;
        list->size = 0;
    }
}

int listAdd(MyList* list, const char* word)
{
    assert(list != NULL);

    if((list->countWords + 1) * (list->wordlen + 1) > list->size)
    {
        size_t newSize = list->size + (list->wordlen + 1) * list->capacity;
        char* data = (char*)realloc(list->data, newSize);

        if(data != NULL)
        {
            list->size = newSize;
            list->data = data;
        }
        else
        {
            perror("Ошибка выделения памяти");
            return -5;
        }
    }

    strcpy(list->data + list->countWords * (list->wordlen + 1), word);
    list->countWords++;
    return 0;
}
