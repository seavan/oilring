use strict;
use warnings;

use Net::Telnet;

my $telnet = new Net::Telnet ( Timeout=>10, Port => 4555,
Errmode=>'die');



my @ids = (150..500);

foreach(@ids)
{
print;
print "\n";
$telnet->open('localhost');
print $telnet->getline();
print $telnet->getline();
print $telnet->getline();
$telnet->print('root');
print $telnet->getline();
$telnet->print('root');
print $telnet->getline();
	#$telnet->print( 'adduser #admin admin');
	#print $telnet->getline();

	#$telnet->print( 'adduser fake_user fake_user');
	#print $telnet->getline();

#	$telnet->print( 'adduser user_' . $_ . ' pass_' . $_ );
#	print $telnet->getline();
	$telnet->print( 'unsetalias user_' . $_  );
	print $telnet->getline();

	$telnet->print( 'setforwarding user_' . $_ . ' admin@oilring.notamedia.ru ' );
	print $telnet->getline();
	$telnet->close();
}

