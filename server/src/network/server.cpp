/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: server.cpp
 * Address Module for this [server] aspect of multiplayer at SETI-Jam */
#include "server.h"
using namespace std;

ServerSocket::ServerSocket() = default;

ServerSocket::ServerSocket(Address& addr)
{
    bind(addr);
}

ServerSocket::~ServerSocket()
{
    this->close();
}

ServerSocket& ServerSocket::bind(Address& addrList)
{
    for(auto& addr : addrList)
    {
        _fd = socket(addr->ai_family, addr->ai_socktype, addr->ai_protocol);
        if(_fd == -1)
            continue;

        this->setSockOpt(SO_REUSEADDR, 1);

        if(::bind(_fd, addr->ai_addr, addr->ai_addrlen) == -1)
            this->close();
        else
            break;

    }

    return *this;
}

ServerSocket& ServerSocket::listen(int backlog)
{
    ::listen(_fd, backlog);
    return *this;
}

ServerSocket& ServerSocket::accept()
{
    ClientAddress addr;
    ClientSocket sock;

    sock = ::accept(_fd, (struct sockaddr*)addr.sa, addr.len);

    if(sock)
        clients.emplace_back(sock, addr);

    return *this;
}

