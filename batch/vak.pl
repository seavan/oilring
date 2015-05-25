#!/usr/bin/perl
use locale;
use POSIX qw (locale_h);
setlocale(LC_CTYPE, 'ru_RU.UTF-8');

print "USE oilring;", "\n";
print "DELETE FROM Rubrics;", "\n";
print "DECLARE \@pid bigint;";
my $accum = "";
while(<>)
{
	my $inp = $_;

	
	if( $inp =~ /.*?¦\s*(.*?)\s*¦\s*(.*?)\s*¦(.*?)¦/ )
	{
		my($index, $title) = ($1, $2);
		my $alias = lc($title);
		$alias =~ tr/àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ ,()/abvgdeejzijklmnoprstufhccssXiXeua____/;
		$alias =~ s/X//;
		$alias =~ s/_+/_/;
		$alias =~ s/_*$//;
		$alias =~ s/^_*//;
		if($index =~ /\d+\.00\.00/)
		{
			print "INSERT INTO Rubrics(Alias, Header, Parent_Rubric_ID) VALUES('$alias', '$title', 0)\n";
			print "SET \@pid = (SELECT \@\@IDENTITY);\n";
			next;
		}
		
		if($index =~ /\d+\.\d+\.00/)
		{
			#print "===", $title, "\n";
			print "INSERT INTO Rubrics(Alias, Header, Parent_Rubric_ID) VALUES('$alias', '$title', \@pid)\n";
			print "SET \@pid = (SELECT \@\@IDENTITY);\n";
			next;
		}
		if( length($title) )
		{
#			print "[", $title, "]\n";
			$accum .= $title;
		}
	}
	
	if( $inp =~ /\+/ )
	{
		$title = $accum;
		my $alias = lc($title);
		$alias =~ tr/àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ ,()/abvgdeejzijklmnoprstufhccssXiXeua____/;
		$alias =~ s/X//;
		$alias =~ s/_+/_/;		
		$alias =~ s/_*$//;
		$alias =~ s/^_*//;
		if(length($title))
		{
			print "INSERT INTO Rubrics(Alias, Header, Parent_Rubric_ID) VALUES('$alias', '$title', \@pid)\n";
		}
		#print ">>>>", $accum, "\n";
		$accum = "";
	}


}