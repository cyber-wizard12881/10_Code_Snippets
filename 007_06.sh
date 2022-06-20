# 6. Find a Regular Expression for an IPV4 Address?
#    eg. 127.0.0.1 is an IPV4 Address.

#!/bin/bash

# The Regex is arrived using the principles of Composition as follows:
# each octet is allowed a value from 0-255
# for a number to lie in the range [0-255]
# we can decompose the problem into smaller parts as follows:
# 0-9: [0-9]
# 10-99: [0-9][0-9] i.e [0-9]{2}
# 100-199: 1[0-9]{2}
# 200-249: 2[0-4][0-9]
# 250-255: 25[0-5]
# .: .
ipv4_regex='^([0-9]|[0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-5]).([0-9]|[0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-5]).([0-9]|[0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-5]).([0-9]|[0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-5])$'

ipv4_address='127.0.0.1'
non_ipv4_address='255.255.255.256'

# the driver command to check whether there's a match or not!
# valid ipv4 address
if [[ $ipv4_address =~ $ipv4_regex ]]
then
  echo "$ipv4_address is a valid ipv4 address!!"
else
  echo "$ipv4_address is not a valid ipv4 address!!"
fi
# invalid ipv4 address
if [[ $non_ipv4_address =~ $ipv4_regex ]]
then
  echo "$non_ipv4_address is a valid ipv4 address!!"
else
  echo "$non_ipv4_address is a not valid ipv4 address!!"
fi
