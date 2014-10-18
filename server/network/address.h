/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: address.h
 * Address Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef ADDRESS_H
#define ADDRESS_H

#include <arpa/inet.h>
#include <netdb.h>

class Address
{
    struct addrinfo *_res;

public:
    Address();
    Address(Address&& other);
    Address(const char *host, const char *port);
    ~Address();

    int getHost(const char *host, const char *port);

};

#endif /* ADDRESS_H */

