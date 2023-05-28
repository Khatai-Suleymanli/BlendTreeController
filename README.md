# Movement Script

The Movement script is a component for controlling character movement and animation in Unity. It provides smooth acceleration, deceleration, and maximum velocity control for both forward/backward and sideways movement. The script also integrates with the Animator component to update animation parameters based on the character's movement.

## Features

- Smooth acceleration and deceleration for character movement
- Separate maximum velocity for walking and running
- Automatic adjustment of velocity based on input
- Integration with Animator component for animation control

## Getting Started

1. Attach the Movement script to your character GameObject in Unity.
2. Assign the required Animator component to the "animator" variable in the script inspector.
3. Configure the desired acceleration, deceleration, and maximum velocity values in the inspector.
4. Ensure that the appropriate input keys (W, A, D, Left Shift, S) are mapped for character movement.

## Usage

- Press and hold the W key to move the character forward.
- Press and hold the A key to move the character to the left.
- Press and hold the D key to move the character to the right.
- Press and hold the Left Shift key while moving forward to make the character run.
- Press and hold the S key to move the character backward.
- Press and hold the right mouse button (Mouse1) to enter aiming mode.

## Notes

- The script assumes that the character model has an Animator component with "vertical" and "horizontal" parameters for controlling animation.
- The script automatically adjusts the velocity based on input and applies acceleration and deceleration for smooth movement transitions.
- The maximum velocity values determine the speed limit for walking and running.
- The script handles different combinations of movement keys to ensure consistent and smooth movement behavior.
