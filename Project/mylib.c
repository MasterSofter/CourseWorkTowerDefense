#include "mylib.h"
#include <assert.h>



char* toLowString(char* result, char* string)
{
    size_t len = strlen(string);
    size_t i;
    for(i = 0; i < len; i ++)
        result[i] = toLowRegistr(string[i]);
    result[i] = '\0';
    return result;
}

char toLowRegistr(char ch)
{
    assert(ch != '\0');

    char* rusAlphabetBig = "ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞß";
    char* rusAlphabetSmall = "àáâãäå¸æçèéêëìíîïðñòóôõöøùúûüýþÿ";

    //Åñëè ñèìâîë àíøëèéñêîãî àëôàâèòà
    if((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
        return (char)tolower(ch);

    int j;
    for(j = 0; rusAlphabetBig[j] != '\0' && ch != rusAlphabetBig[j]; j ++);

    if(rusAlphabetBig[j] != '\0')
        return rusAlphabetSmall[j];
    else
        return ch;
}

int findWordsByLen(MyList* mylist, char* buff)
{
    assert(mylist != NULL);
    assert(buff != NULL);
    const char* endWordSymb = " \t,;:!?.)}>";

    char* pWord;                                    // óêàçàòåëü íà ëåêñåìó
    pWord = strtok(buff, endWordSymb);             // âûäåëÿåì ñëîâî è ñîõðàíÿêì óêàçàòåëü íà íåãî

    while (pWord != NULL)
    {
        if(pWord[strlen(pWord) - 1] == '\n')        // Åñëè â êîíöå ñëîâà \n ïîñòàâèòü âìåñòî íåãî \0
            pWord[strlen(pWord) - 1] = '\0';

        if(pWord[(int)strlen(pWord)-1] == '"')
            pWord[(int)strlen(pWord)-1] = '\0';

        if(strlen(pWord) == mylist->wordlen)                    // Åñëè äëèíà òåêóùåãî ðàâíà len
            listAdd(mylist, pWord);                 // Äîáàâèòü â êîíåö ñïèñêà íîâóþ ïîçèöèþ â ôàéëå

        pWord = strtok (NULL, endWordSymb);       // Âûäåëåíèå î÷åðåäíîé ÷àñòè ñòðîêè (ñëîâà)
    }
    return  mylist->countWords;
}