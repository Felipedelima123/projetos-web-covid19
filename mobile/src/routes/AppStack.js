import React from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Profile from '../screens/Profile';
import Home from '../screens/Home';
const {Navigator, Screen} = createBottomTabNavigator();

function AppStack() {
  return (
    <Navigator>
      <Screen name="Profile" component={Profile} />
      <Screen name="Home" component={Home} />
    </Navigator>
  );
}

export default AppStack;
