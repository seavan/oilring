
use strict;

while(<>)
{
	if(m/^_/)
	{
		print "UPDATE $_ SET REL_ObjectType1 = RTRIM(LTRIM(REL_ObjectType1))\r\nGO\r\n";
		print "UPDATE $_ SET REL_ObjectType2 = RTRIM(LTRIM(REL_ObjectType2))\r\nGO\r\n";

	}
	else
	{
		print "UPDATE $_ SET ObjectType = RTRIM(LTRIM(ObjectType))\r\nGO\r\n";
		print "UPDATE $_ SET REL_ObjectType = RTRIM(LTRIM(REL_ObjectType))\r\nGO\r\n";

	}
}