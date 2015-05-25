wget\wget.exe -O rss.xml http://news.yandex.ru/energy.rss
msxsl rss.xml rss.xsl > rss.sql
wget\iconv.exe -f utf-8 -t cp1251 rss.sql > rss2.sql
sqlcmd -S 46.46.156.42 -Uoilring_web -Pkimberlite_1414 -d oilring -irss2.sql
