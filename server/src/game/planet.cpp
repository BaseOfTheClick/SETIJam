#include "planet.h"

SpaceObject::SpaceObject() = default;

const int SpaceObject::x() const { return co.x; }
const int SpaceObject::y() const { return co.y; }

SpaceObject::Vector2D&
SpaceObject::vector() { return co; }

Planet::Planet() = default;

