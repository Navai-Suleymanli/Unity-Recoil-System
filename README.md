# Recoil System

This code represents a Recoil System implemented in Unity using C#. It is designed to provide a recoil effect for a gun in a game.

## Features

- Singleton instance: The `RecoilSystem` class is implemented as a singleton, ensuring that only one instance of the class exists at any given time. The instance can be accessed through the `Instance` property.

- Gun reference: The code includes a reference to a gun game object (`Gun`). It retrieves the `Gun` script attached to the same game object and uses it for certain functionality.

- Animator component: The code utilizes the Animator component attached to the game object to control animations.

- Event subscription: The code subscribes to an event (`OnBulletCountChanged`) from the `PlayerManager` script, allowing it to respond to changes in the bullet count.

- Auto fire and bullet management: The code checks for input from the player to initiate auto fire if the gun is set to automatic mode (`isAuto`) and there are bullets available (`bullet > 0`). It also updates the Animator's "AutoFire" parameter accordingly.

- Recoil animation: When the player fires the gun in non-automatic mode (`!gun.isAuto`), the code starts a coroutine (`StartRecoil`) to initiate a recoil effect. The coroutine plays the "RecoilAnimation" state in the Animator for a short duration and then switches back to the "New State" state.

## Usage

1. Attach the `RecoilSystem` script to a game object in your Unity scene.

2. Assign the necessary references in the inspector:
   - `Gun`: Reference to the gun game object.
   - `PlayerManager`: Reference to the `PlayerManager` script attached to the game object.

3. Ensure the gun game object has an Animator component attached, and animations are set up with appropriate states, including "RecoilAnimation" and "New State".

4. If needed, customize the code according to your specific requirements. For example, you can modify the input conditions or adjust the duration of the recoil effect.

## Disclaimer

I did not write this code. This is an example of a Recoil System implementation in Unity using C#. It is provided for reference purposes and can be used and modified as per your needs.
