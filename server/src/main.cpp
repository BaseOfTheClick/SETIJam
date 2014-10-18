/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * The main executable for a [server] portion of our SETI-Jam game */
#include "log/log.h"
#include "network/address.h"
#include "network/server.h"
#include <iostream>
using namespace std;

int main(int argc, char *argv[])
{
    LogFile log("test.log");

    log << "*******************************"
        << "Server executable started";

    const char * const HOST = "10.255.103.177";
    const char * const PORT = "31337";

    Address addr(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(!addr.getHost(HOST, PORT))
    {
        log << "Unable to resolve host";
        return 1;
    }
    else
    {
        log << "Resolved host";
    }

    ServerSocket server;
    server.setSockOpt(SO_REUSEADDR);
    if(server.bind(addr) <= 0)
    {
        log << "Unable to bind to host";
        return 2;
    }
    else
    {
        log << "Bound to host";
    }

    cout << "Server FD: " << server << endl;

    if(!server.listen(10))
    {
        log << "Unable to listen to host";
        return 3;
    }
    else
    {
        log << "Listening on host";
    }

    cout << "Listening!\n";

    if(!server.accept())
    {
        log << "Couldn't accept a connection\n";
        return 4;
    }
    else
    {
        log << "Accepted a client connection!\n";
    }

    return 0;
}


