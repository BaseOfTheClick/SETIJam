/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: address.cpp
 * Address Module for this [server] aspect of multiplayer at SETI-Jam */
#include "address.h"

Address::Address() : _res(nullptr)
{
}

Address::Address(Address&& other) : _res(other._res)
{
}

Address::Address(const char *host, const char *port)
{
}

Address::~Address()
{
}

int Address::getHost(const char *host, const char *port)
{
    return 0;
}

