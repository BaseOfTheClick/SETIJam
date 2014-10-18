/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * The main executable for a [server] portion of our SETI-Jam game */
#include "log/log.h"
#include "network/address.h"
#include "network/server.h"
#include "network/select.h"
#include <iostream>
using namespace std;

const char * const HOST = "10.255.103.177";
const char * const PORT = "31337";

void logHost(LogFile& log, const string& message)
{
    log << message + " " + string(HOST) + ":" + string(PORT);
}

#include <unistd.h>

int main(int argc, char *argv[])
{
    LogFile log("test.log");

    log << "**************************"
        << "New server session started";

    Address addr(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(!addr.getHost(HOST, PORT))
    {
        logHost(log, "Unable to resolve");
        return 1;
    }
    else
    {
        logHost(log, "Resolved");
    }

    ServerSocket server;
    if(server.bind(addr) <= 0)
    {
        logHost(log, "Unable to bind to");
        return 2;
    }
    else
    {
        logHost(log, "Bound to");
    }

    cout << "Server FD: " << server << endl;

    if(!server.listen(10))
    {
        logHost(log, "Unable to listen on");
        return 3;
    }
    else
    {
        logHost(log, "Listening on");
        cout << "Listening on " << HOST << ":" << PORT << endl;
    }

    /*
    // Setup multiplexer here
    Multiplexer select;
    server.setSockOpt(O_NONBLOCK, 1);
    select.insert(&server);
    */
    /*
    vector<Client> clients;
    */

    vector<ClientSocket> clients;

    fd_set afds, rfds;

    // Initialize rfds with server socket
    server.setNonBlock(1);

    FD_ZERO(&afds);
    FD_ZERO(&rfds);
    FD_SET(server, &afds);

    // Set highest fd
    int max = server;

    while(true)
    {
        rfds = afds;
        int sel = select(FD_SETSIZE, &rfds, nullptr, nullptr, nullptr);
        if(sel == -1)
            continue;
        else if(!sel)
        {
            cout << "No data\n";
            continue;
        }

        for(int i = 0; i < FD_SETSIZE; ++i)
        {
            if(FD_ISSET(i, &rfds) && i == server)
            {
                clients.emplace_back(ClientSocket());
                clients.back() = server.accept();
                if(clients.back() > 0)
                {
                    cout << "Client connected\n";

                    clients.back().setNonBlock(1);
                    FD_SET(clients.back(), &afds);
                    max = clients.back();
                }

                cout << clients.back() << endl;
            }
            else if(FD_ISSET(i, &rfds))
            {
                char buf[256];
                int b = read(i, buf, 255);
                if(b > 0)
                {
                    buf[b - 1] = '\0';
                    cout << buf << endl;
                }
                else
                {
                    FD_CLR(i, &afds);
                    for(auto it = clients.cbegin();
                        it != clients.cend(); ++it)
                    {
                        if(*it == i)
                            clients.erase(it);
                    }
                    cout << "Socket " << i << " disconnected\n";
                }
            }
        }

    }

    return 0;
}


