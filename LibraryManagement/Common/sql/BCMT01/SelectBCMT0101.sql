﻿SELECT  
    BOOK_ID as 'ID',  
    BOOK_NAME as 'タイトル',  
    DIVISION_NAME1 as '分類1', 
    DIVISION_NAME2 as '分類2', 
    DIVISION_NAME3 as '分類3', 
    USER_MASTER.USER_NAME as '入荷者', 
    ARRIVAL_DATE as '入荷日'  
FROM  
    (SELECT *, BOOK_GENRE_MASTER.DIVISION_NAME as 'DIVISION_NAME3'  
    FROM  
        (SELECT *, BOOK_GENRE_MASTER.DIVISION_NAME as 'DIVISION_NAME2'  
        FROM  
            (SELECT *, BOOK_GENRE_MASTER.DIVISION_NAME as 'DIVISION_NAME1'  
            FROM  
                BOOK_MASTER 
            LEFT OUTER JOIN 
                BOOK_GENRE_MASTER 
            ON 
                DIVISION_ID1 = BOOK_GENRE_MASTER.DIVISION_ID 
            ) 
        LEFT OUTER JOIN  
            BOOK_GENRE_MASTER  
        ON  
            DIVISION_ID2 = BOOK_GENRE_MASTER.DIVISION_ID  
        ) 
    LEFT OUTER JOIN  
        BOOK_GENRE_MASTER  
    ON  
        DIVISION_ID3 = BOOK_GENRE_MASTER.DIVISION_ID  
    ) 
LEFT OUTER JOIN  
    USER_MASTER  
ON  
    ARRIVAL_USER_ID = USER_MASTER.USER_ID 
WHERE  
    BOOK_ID LIKE '%{0}%'
    AND BOOK_NAME LIKE '%{1}%'
