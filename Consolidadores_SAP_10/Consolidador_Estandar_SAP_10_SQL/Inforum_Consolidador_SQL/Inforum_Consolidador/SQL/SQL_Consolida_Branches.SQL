SELECT DISTINCT(T0."BRANCH") AS BRANCH      
FROM
(
SELECT  
      T1."FormatCode" ACCOUNTCODE,
      CASE WHEN T1."GroupMask" IN (2,3,4,7)
            THEN ROUND(SUM(IFNULL(T0."Credit",0) - IFNULL(T0."Debit",0)),2)
            ELSE 0
            END CREDIT,
       CASE WHEN T1."GroupMask" IN (2,3,4,7)
            THEN ROUND(SUM(IFNULL(T0."SYSCred",0) - IFNULL(T0."SYSDeb",0)),2)
            ELSE 0
            END "CREDITMS",
      CASE WHEN T1."GroupMask" IN (1,5,6,8)
            THEN ROUND(SUM(IFNULL(T0."Debit",0) - IFNULL(T0."Credit",0)),2)
            ELSE 0
            END DEBIT,
      CASE WHEN T1."GroupMask" IN (1,5,6,8)
            THEN ROUND(SUM(IFNULL(T0."SYSDeb",0) - IFNULL(T0."SYSCred",0)),2)
            ELSE 0
            END "DEBITMS",            
      CASE WHEN (SELECT "MltpBrnchs" from DATABASE.OADM)='Y'
      THEN T0."BPLId"
      ELSE NULL
      END BRANCH
              
      FROM DATABASE.JDT1 T0
      INNER JOIN DATABASE.OACT T1 ON T0."Account" = T1."AcctCode"
      INNER JOIN DATABASE.OJDT T2 ON T0."TransId" = T2."TransId"
      WHERE T0."RefDate" BETWEEN 'FECHAINICIAL' AND 'FECHAFINAL' ------FILTRO DE FECHAS
      AND T2."TransType" NOT IN (-2,-3) ------EXCLUIR PARTIDAS DE CIERRE Y APERTURA
 
      GROUP BY T0."BPLId", T1."FormatCode", T1."GroupMask"
      ORDER BY T0."BPLId", T1."FormatCode", T1."GroupMask"
)
    T0
      INNER JOIN DATABASE.OACT T1 ON T0."ACCOUNTCODE" = T1."FormatCode"
      AND (ABS(ROUND(T0."DEBIT",2)) - ABS(ROUND(T0."CREDIT",2)) +ABS(ROUND(T0."DEBITMS",2))- ABS(ROUND(T0."CREDITMS",2)) != 0.00)
    ORDER BY T0."BRANCH"
