import * as React from "react";
import { useState, useEffect } from "react";
import styles from "./index.module.scss";
export interface IModalLoginProps {
  show: boolean;
  onClose: () => void;
  checkUserLogin: () => void;
}

interface IUser {
  username: string;
  password: string;
  email: string;
  avater: string;
  id: string;
}

export default function ModalLogin(props: IModalLoginProps) {
  const { onClose, checkUserLogin } = props;
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [userLogin, setUserLogin] = useState<IUser>();

  const handleLogin = () => {
    fetch("https://localhost:7076/api/Users/login", {
      method: "POST",
      body: JSON.stringify({
        Username: userName,
        Password: password,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => {
        return res.json();
      })
      .then((user) => {
        setUserLogin(user);
        setUserName("");
        setPassword("");
        localStorage.setItem(
          "user",
          JSON.stringify({
            userName: user.username,
            isLogin: true,
          })
        );
        checkUserLogin();
        onClose();
      });
  };

  if (!props.show) return null;
  return (
    <div className={styles.modal} onClick={onClose}>
      <div className={styles.modelContent} onClick={(e) => e.stopPropagation()}>
        <div className={styles.modalHeader}>
          <h3 className={styles.logoLogin}>Intern Fetch</h3>
        </div>
        <div className={styles.modalBody}>
          <input
            placeholder="username"
            value={userName}
            type="text"
            onChange={(e) => setUserName(e.target.value)}
            className={styles.loginInput}
          />
          <input
            placeholder="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            type="text"
            className={styles.loginInput}
          />
          <button onClick={handleLogin} className={styles.btnLogin}>
            Log In
          </button>
          <a href="#" className={styles.loginForgot}>
            Forgot Password?
          </a>
          <button className={styles.btnNewAccount}>Create new account</button>
        </div>
      </div>
    </div>
  );
}
