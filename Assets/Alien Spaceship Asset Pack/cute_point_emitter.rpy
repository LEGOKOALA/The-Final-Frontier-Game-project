# Permission is hereby granted, free of charge, to any person
# obtaining a copy of this software and associated documentation files
# (the "Software"), to deal in the Software without restriction,
# including without limitation the rights to use, copy, modify, merge,
# publish, distribute, sublicense, and/or sell copies of the Software,
# and to permit persons to whom the Software is furnished to do so,
# subject to the following conditions:
#
# The above copyright notice and this permission notice shall be
# included in all copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
# EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
# MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
# NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
# LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
# OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
# WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


# CuteShadow PointEmitter: Version 1.2.2


####################### EXAMPLE USAGE ##########################
# image emitter = PointEmitter(count=500)
#
# label emitter_demo:
#
#     # Add the emitter to the screen.
#     show emitter
#
#     "Do you like my particles?"
#
#     hide emitter
#
#     return
################################################################


init 2 python:

    import math
    import random

    class PointEmitter(SpriteManager):
        def __init__(self, sprite=Solid("ff0000",xysize=(10,10)), count=100, pos=(config.screen_width/2,config.screen_height/2), radius=300, rotate=0, slice=360, speed=1.0, warmup_time=2.0):
            """
            `sprite`
                This is the image the emitter will use.

            `count`
                This is how many particles will appear.

            `pos`
                The x,y position of the particle source.
                Defaults to the center of the screen.

            `radius`
                This is how far particles will travel before
                resetting to the source.

            `rotate`
                The overall orientation (in degrees) of the effect.

            `slice`
                This is the angle (in degrees) the particles are limited
                to travel in.

            `speed`
                This is the speed multiplier the particles
                will travel at.

            `warmup_time`
                This is how long it will take for all particles
                to become active in seconds greater than 0.
                A small number will have the particles group up
                whereas a bigger number will spread them out.
                When not active, particles wait at the source.
            """
            # Assign the basic attributes.
            self.sprite = sprite
            self.pos = pos
            self.radius = radius
            self.rotate = rotate
            self.slice = slice
            self.speed = speed
            self.warmup_time = warmup_time

            # Create a new update function for the SpriteManager 
            # given this PointEmitter's init values.
            super().__init__(update=self.point_emitter_update)

            # Create the sprites list attribute now.
            self.emitter_sprites = [ ]
            # Add sprites.
            for i in range(count):
                self.emitter_sprites.append(self.create(sprite))
            # Position the sprites.
            for i in self.emitter_sprites:
                i.x = 0
                i.y = 0

        def point_emitter_update(self, st):
            # Set the constants before being passed into the SpriteManager.
            initial_x, initial_y = self.pos
            boundary_radius = self.radius
            initial_angle_rad = math.radians(self.rotate)
            sector_angle_rad = math.radians(self.slice)
            speed_multiplier = self.speed
            warmup_time = self.warmup_time

            # For each sprite...
            for index, particle in enumerate(self.emitter_sprites):
                # It will take warmup_time seconds for all sprites to show up.
                # But when they do they will be offset so they
                # don't all show up synchronously.
                if st >= index/(len(self.emitter_sprites)/warmup_time):
                    # Calculate current distance from the origin
                    dx = particle.x - initial_x
                    dy = particle.y - initial_y
                    distance = math.sqrt(dx ** 2 + dy ** 2)
                    prev_distance = 0
                    print(distance)

                    # Assign a new random direction and speed
                    angle = random.uniform(-sector_angle_rad / 2, sector_angle_rad / 2) + initial_angle_rad
                    speed = random.uniform(3, 5)

                    # When the speed is positive, emmenate from the origin.
                    if speed_multiplier >= 0:

                        # Check if the particle needs to be reset
                        if distance >= boundary_radius or distance == 0:
                            # Reset to initial position
                            particle.x = initial_x
                            particle.y = initial_y

                            # Move the particle immediately to avoid lingering at the center
                            particle.x += math.cos(angle) * speed * speed_multiplier
                            particle.y += math.sin(angle) * speed * speed_multiplier
                        else:
                            # Continue moving the particle in the current direction
                            angle = math.atan2(dy, dx)
                            speed = 5  # Keep a consistent outward speed

                            particle.x += math.cos(angle) * speed * speed_multiplier
                            particle.y += math.sin(angle) * speed * speed_multiplier
                    

                    # When the speed is negative, go to the origin instead.
                    else:
                        
                        # Check if we are at the origin.
                        if distance <= 10 or distance > boundary_radius+10:

                            # Spawn at the edge of the circle.
                            particle.x = initial_x + boundary_radius * math.cos(angle)
                            particle.y = initial_y + boundary_radius * math.sin(angle)
                            
                        # If we are anywhere else, continue moving to the origin.
                        else:
                            # Angle toward the origin
                            angle = math.atan2(initial_y - particle.y, initial_x - particle.x) 
                            speed = 5

                            particle.x += math.cos(angle) * speed * -speed_multiplier
                            particle.y += math.sin(angle) * speed * -speed_multiplier

                    

                else:
                    # Just wait at the start if warmup_time isn't up yet.
                    particle.x, particle.y = -5000,-5000#initial_x, initial_y

            # We'll update the SpriteManager every this amount of seconds.
            return .01
