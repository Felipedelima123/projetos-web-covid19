import { createStackNavigator } from '@react-navigation/stack';
import React from 'react';
import SignIn from '../screens/SignIn';

const { Navigator, Screen } = createStackNavigator();

function AuthStack() {
  return (
    <Navigator
      screenOptions={() => ({ headerShown: false })}
    >
      <Screen name="SignIn" component={SignIn} />
    </Navigator>
  );
}

export default AuthStack;
