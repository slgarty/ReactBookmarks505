import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './pages/Home';
import Signup from './pages/Signup';
import Login from './pages/Login';
import MyBookmarks from './pages/MyBookmarks';
import AddBookmark from './pages/AddBookmark';
import AuthContextComponent from './AuthContext';
import PrivateRoute from './PrivateRoute';
import Logout from './pages/Logout';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <AuthContextComponent>
        <Layout>
          <Route exact path='/' component={Home} />
          <Route exact path='/signup' component={Signup} />
          <Route exact path='/login' component={Login} />
          <Route exact path='/logout' component={Logout} />
          <PrivateRoute exact path='/my-bookmarks' component={MyBookmarks} />
          <PrivateRoute exact path='/add-bookmark' component={AddBookmark} />
        </Layout>
      </AuthContextComponent>
    );
  }
}
