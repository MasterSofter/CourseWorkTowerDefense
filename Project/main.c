#include "mylib.h"
#include <stdio.h>
#include <string.h>


int compare (void* _str1, void* _str2)
{
    char* str1 = (char*)_str1;
    char* str2 = (char*)_str2;

    size_t len = strlen(str1);

    char buff1[len];
    char buff2[len];

    return strcmp(toLowString(buff1, str1), toLowString(buff2, str2));
}

void process(FILE* file, FILE* fout, MyList* myList)
{
    char buff[STR_LEN];
    if(fgets(buff, STR_LEN, file) == NULL)
    {
        if(ftell(file) == 0)
        {
            printf("Входной файл пуст");
            return;
        }
            //иначе, мы ничего не можем сделать, даже если ftell неправильно сработал!
        else
        {
            perror("Ошибка при работе с входым файлом!");
            return;
        }

    }

    do{
        //поиск слов заданной длины
        findWordsByLen(myList, buff);
    }while (fgets(buff, STR_LEN, file) != NULL);

    if(ferror(file))
    {
        perror("Ошибка чтения из файла!");
        return;
    }


    qsort(myList->data, myList->countWords, myList->wordlen + 1, compare);

    for(int i = 0; i < myList->countWords; i ++)
    {
        fwrite(myList->data + i * (myList->wordlen + 1), myList->wordlen , 1, fout);
        if(ferror(fout))
        {
            perror("Ошибка записи в выходной файл!");
            return;
        }

        fputc('\n',fout);
    }
}

const unsigned char MAX_LEN_WORD = 55;

int main (int argc, char** argv) {
    if(argc < 3)
    {
        printf("\nОшибка! Не достает кол-во передаваемых параметров в программу! Передача должна осуществляться следующим образом:\n"
               "** Первый аргумент - входной файл\n"
               "** Воторй аргумент - выходной файл\n"
               "** Третий аргумент - длина искомых слов (макс. длина возможного искомого слова: 55 букв)\n ");
        return -1;
    }

    if(strcmp(argv[1], argv[2]) == 0)
    {
        printf("\nОшибка! Путь и имя выходного файла не должны совпадать с входным файлом!");
        return -2;
    }
    if(atoi(argv[3]) > MAX_LEN_WORD)
    {
        printf("\nОшибка! Слово указанной длины ни в русском, ни в английском языке не существует! Максимальная длина слова - 55");
        return -3;
    }

    if(atoi(argv[3]) <= 0)
    {
        printf("\nОшибка! Длина искомого слова должна быть положительной!");
        return -4;
    }

    FILE* file = NULL;
    FILE* fout = NULL;
    MyList myList;

    int wordlen = atoi(argv[3]);
    int error = 0;

    const char* fName = argv[1];
    const char* fOutName = argv[2];

    unsigned short listCapacity = 10; // вместимость списка
    //Создание и инициализация списка
    if((error = listInit(&myList, listCapacity, wordlen)) != 0)
    {
        printf("Ошибка выделения памяти");
        return error;
    }

    //Открытие файла на чтение
    if((file = fopen(fName, "r")) == NULL)
    {
        perror("Ошибка, файл для чтения не открыт!");
        listClear(&myList);
        return -1;
    }

    if((fout = fopen(fOutName, "w")) == NULL)
    {
        perror("Ошибка, не удалось открыть файл на запись!");
        fclose(file);
        listClear(&myList);
        return -4;
    }

    process(file, fout, &myList);

    //Закрытие файлов
    fclose(fout);
    fclose(file);

    //Очистка списка, высвобождение памяти
    listClear(&myList);

    return 0;
}
