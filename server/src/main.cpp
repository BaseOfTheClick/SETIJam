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
        log.write("Unable to resolve ", HOST, ":", PORT);
        return 1;
    }
    else
    {
        log.write("Resolved ", HOST, ":", PORT);
    }

    ServerSocket server;
    if(server.bind(addr) <= 0)
    {
        log.write("Unable to bind to ", HOST, ":", PORT);
        return 2;
    }
    else
    {
        log.write("Bound to ", HOST, ":", PORT);
    }

    cout << "Server FD: " << server << endl;

    if(!server.listen(10))
    {
        log.write("Unable to listen on ", HOST, ":", PORT);
        return 3;
    }
    else
    {
        log.write("Listening on ", HOST, ":", PORT);
        cout << "Listening on " << HOST << ":" << PORT << endl;
    }

    if(!server.accept())
    {
        log.write("Rejected a client on ", HOST, ":", PORT);
        return 4;
    }
    else
    {
        log.write("Accepted a client on ", HOST, ":", PORT);
    }

    return 0;
}


