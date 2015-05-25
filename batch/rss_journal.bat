wget\wget.exe -O rss.xml http://lenta.ru/r/EX/import.xml
msxsl rss.xml rss_journal.xsl > rss.sql
wget\iconv.exe -f utf-8 -t cp1251 rss.sql > rss2.sql
sqlcmd -S oilring.notamedia.ru -Uoilring -Pkimberlite_1414 -d oilring -irss2.sql