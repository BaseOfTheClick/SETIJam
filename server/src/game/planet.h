#ifndef PLANET_H
#define PLANET_H

class SpaceObject
{
protected:    
    struct Vector2D
    {
        int x, y;
    };

    Vector2D co;

public:
    SpaceObject();

    const int x() const;
    const int y() const;

    Vector2D& vector();
};

class Resources
{
private:
    struct Aspect
    {
        int level {75};
        int max {100};
    };

    Aspect eco, politics, research;
};

class Planet : public SpaceObject
{
    Resources res;

public:
    Planet();

};

#endif


