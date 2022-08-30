import * as React from "react";
import { useState, useEffect } from "react";
import { Col, Container, Row } from "react-bootstrap";
import "./index.scss";
import ModalLogin from "../../../modal/login";

export interface IHeaderProps {}

interface IUser {
  username: string;
  password: string;
  email: string;
  avater: string;
  comments: string | null;
  posts: string | null;
  room: string | null;
  userRooms: string | null;
  id: string;
  deleteAt: string | null;
  createdDate: string;
  updatedDate: string;
}

interface IUserLogin {
  username: string;
  password: string;
  email: string;
  avater: string;
  id: string;
}

export default function Header(props: IHeaderProps) {
  const [users, setUsers] = useState<IUser[]>([]);
  const [baseUser, setBaseUser] = useState<IUser[]>([]);
  const [show, setShow] = useState<boolean>(false);
  const [isLogin, setIsLogin] = useState<boolean>(false);

  useEffect(() => {
    fetch("https://localhost:7076/api/Users")
      .then((res) => res.json())
      .then((users) => {
        setUsers(users);
        setBaseUser(users);
      });
  }, []);

  const checkUserLogin = () => {
    const user = JSON.parse(localStorage.getItem("user")!);
    if (!user) {
      setIsLogin(false);
    } else {
      setIsLogin(user.isLogin);
    }
  };

  const logout = () => {
    const user = JSON.parse(localStorage.getItem("user")!);
    if (user) {
      localStorage.removeItem("user");
      checkUserLogin();
    }
  };
  useEffect(() => {
    checkUserLogin();
  }, []);

  const onClose = React.useCallback(() => {
    setShow(false);
  }, []);

  const handleSearchChange = (e: any) => {
    let currentUsers = [...baseUser];
    currentUsers = baseUser.filter((user: IUser) =>
      user.username.includes(e.target.value)
    );
    setUsers(currentUsers);
  };

  return (
    <div>
      <Container fluid="md" className="Header">
        <h1>Intern Fetch</h1>

        <form action="" className="search-input">
          <input onChange={handleSearchChange} className="search-bar" />
          <span className="border-line"></span>
          <button className="search-button">Search</button>
          <ul>
            {users.map((user: IUser) => {
              return <li key={user.id}>{user.username}</li>;
            })}
          </ul>
        </form>

        <div className="ActButton">
          <button className="upbutton">Upload</button>
          {isLogin && <button className="messbutton">Message</button>}
          {!isLogin ? (
            <React.Fragment>
              <button onClick={() => setShow(true)} className="loginButton">
                Login
              </button>
            </React.Fragment>
          ) : (
            <button onClick={logout} className="loginButton">
              Logout
            </button>
          )}
          <ModalLogin
            checkUserLogin={checkUserLogin}
            onClose={onClose}
            show={show}
          />
        </div>
      </Container>
      <hr />
    </div>
  );
}
