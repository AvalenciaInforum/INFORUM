SELECT T0."ACCOUNTCODE",
      CASE WHEN T1."GroupMask" IN (2,3,4,7) AND T0."CREDIT" < 0
            THEN - T0."CREDIT"
            WHEN T1."GroupMask" IN (1,5,6,8) AND T0."DEBIT" < 0
            THEN 0.00            
            ELSE T0."DEBIT"       
      END DEBIT,     
      CASE WHEN T1."GroupMask" IN (1,5,6,8) AND T0."DEBIT" < 0
            THEN - T0."DEBIT"
            WHEN T1."GroupMask" IN (2,3,4,7) AND T0."CREDIT" < 0
            THEN 0.00
            ELSE T0."CREDIT"
	END CREDIT,
	CASE WHEN T1."GroupMask" IN (2,3,4,7) AND T0."CREDITMS" < 0
            THEN - T0."CREDITMS"
            WHEN T1."GroupMask" IN (1,5,6,8) AND T0."DEBITMS" < 0
            THEN 0.00            
            ELSE T0."DEBITMS"       
      END "DEBIT MS", 
      CASE WHEN T1."GroupMask" IN (1,5,6,8) AND T0."DEBITMS" < 0
            THEN - T0."DEBITMS"
            WHEN T1."GroupMask" IN (2,3,4,7) AND T0."CREDITMS" < 0
            THEN 0.00
            ELSE T0."CREDITMS"
END "CREDIT MS",	
T0.BRANCH AS BRANCH,
T0."Proyecto" as "Proyecto",
T0."CC1" as "CC1",
T0."CC2" as "CC2",
T0."CC3" as "CC3",
T0."CC4" as "CC4",
T0."CC5" as "CC5"      
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
			END BRANCH,
	  IFNULL(T0."Project",'') as "Proyecto",
	  IFNULL(T0."ProfitCode",'') as "CC1",
	  IFNULL(T0."OcrCode2",'') as "CC2",
	  IFNULL(T0."OcrCode3",'') as "CC3",              
	  IFNULL(T0."OcrCode4",'') as "CC4",
	  IFNULL(T0."OcrCode5",'') as "CC5"
      FROM DATABASE.JDT1 T0
      INNER JOIN DATABASE.OACT T1 ON T0."Account" = T1."AcctCode"
      INNER JOIN DATABASE.OJDT T2 ON T0."TransId" = T2."TransId"
      WHERE T0."RefDate" BETWEEN 'FECHAINICIAL' AND 'FECHAFINAL' ------FILTRO DE FECHAS
      AND T2."TransType" NOT IN (-2,-3) ------EXCLUIR PARTIDAS DE CIERRE Y APERTURA
	  AND T0."BPLId" = SUCURSAL
 
      GROUP BY T0."BPLId", T1."FormatCode", T1."GroupMask", T0."Project", T0."ProfitCode", T0."OcrCode2", T0."OcrCode3", T0."OcrCode4", T0."OcrCode5"
      ORDER BY T0."BPLId", T1."FormatCode", T1."GroupMask"
)
    T0
      INNER JOIN DATABASE.OACT T1	ON T0."ACCOUNTCODE" = T1."FormatCode"
      AND (ABS(ROUND(T0."DEBIT",2)) - ABS(ROUND(T0."CREDIT",2)) +ABS(ROUND(T0."DEBITMS",2))- ABS(ROUND(T0."CREDITMS",2)) != 0.00)
   	ORDER BY T0."BRANCH", T0."ACCOUNTCODE"