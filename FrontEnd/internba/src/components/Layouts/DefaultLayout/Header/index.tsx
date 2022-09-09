import * as React from "react";
import { useState, useEffect } from "react";
import styles from "./Header.module.scss";
import ModalLogin from "../../../modal/login";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import Modal from "../../../common/modal";
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
  const [search, setSearch] = useState<string>("");
  const [show, setShow] = useState<boolean>(false);
  const [isLogin, setIsLogin] = useState<boolean>(false);
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [rePassword, setRePassword] = useState<string>("");
  const [userLogin, setUserLogin] = useState<IUser>();
  const [numberAction, setNumberAction] = useState<number>(1);
  const [filter, setFilter] = useState("");

  // useEffect(() => {
  //   fetch("https://localhost:7076/api/Users")
  //     .then((res) => res.json())
  //     .then((users) => {
  //       setUsers(users);
  //       setBaseUser(users);
  //     });
  // }, []);

  const checkUserLogin = () => {
    const user = JSON.parse(localStorage.getItem("user")!);
    if (!user) {
      setIsLogin(false);
    } else {
      setIsLogin(user.isLogin);
    }
  };

  const checkPassword = () => {
    if (password !== rePassword) {
      return true;
    } else {
      return false;
    }
  };

  const handleCreateNewAccount = () => {
    if (!checkPassword) {
      setNumberAction(2);
    } else {
      fetch(`https://localhost:7076/api/Users/account`, {
        method: "POST",
        body: JSON.stringify({
          userAccountViewModel: {
            username: userName,
            password: password,
          },
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
          setRePassword("");
          setNumberAction(1);
          // checkUserLogin();
          // onClose();
        });
    }
  };

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
            userId: user.id,
          })
        );
        checkUserLogin();
        onClose();
      });
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

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    fetch(`https://localhost:7076/api/Users/search?search=${e.target.value}`, {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => {
        return res.json();
      })
      .then((users) => {
        // setSearch("");
        return setUsers(users);
      });
    console.log(users);
  };

  const hanldeResetPassword = () => {
    if (!checkPassword) {
      setNumberAction(3);
    } else {
      fetch(`https://localhost:7076/api/Users/password`, {
        method: "PUT",
        body: JSON.stringify({
          userFogotPasswordViewModel: {
            username: userName,
            password: password,
          },
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
          setRePassword("");
          setNumberAction(1);
          // checkUserLogin();
          // onClose();
        });
    }
  };
  return (
    <React.Fragment>
      <div className={styles.Header}>
        <div className={styles.headIcon}>Intern Fetch</div>
        <div className={styles.searchBar}>
          <form className={styles.searchInput}>
            <div className={styles.dropdown}>
              <input
                onChange={handleSearchChange}
                className={styles.searchBox}
                placeholder="Username..."
              />
              {
                <div className={styles.dropdownContent}>
                  <a>Hello</a>
                  {users?.map((user: IUser) => {
                    return <a key={user.id}>{user.username}</a>;
                  })}
                </div>
              }
            </div>
            <button className={styles.searchButton}>
              <FontAwesomeIcon icon={faMagnifyingGlass} />
            </button>
            {/* <ul>
              {users.map((user: IUser) => {
                return <li key={user.id}>{user.username}</li>;
              })}
            </ul> */}
          </form>
        </div>
        <div className={styles.actButton}>
          {isLogin && <button className={styles.button}>Message</button>}
          {!isLogin ? (
            <React.Fragment>
              <button onClick={() => setShow(true)} className={styles.button}>
                Login
              </button>
            </React.Fragment>
          ) : (
            <button onClick={logout} className={styles.button}>
              Logout
            </button>
          )}
          <Modal
            title="Intern Fetch"
            show={show}
            onClose={() => {
              setShow(false);
              setNumberAction(1);
            }}
            checkUserLogin={checkUserLogin}
          >
            {numberAction === 1 && (
              <>
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
                <a
                  onClick={() => setNumberAction(3)}
                  className={styles.loginForgot}
                >
                  Forgot Password?
                </a>
                <button
                  onClick={() => setNumberAction(2)}
                  className={styles.btnNewAccount}
                >
                  Create new account
                </button>
              </>
            )}
            {numberAction === 2 && (
              <>
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
                <input
                  placeholder="Confirm password"
                  value={rePassword}
                  onChange={(e) => setRePassword(e.target.value)}
                  type="text"
                  className={styles.loginInput}
                />
                <button
                  onClick={handleCreateNewAccount}
                  className={styles.btnLogin}
                >
                  Create new account
                </button>
                <a
                  onClick={() => setNumberAction(3)}
                  className={styles.loginForgot}
                >
                  Forgot Password?
                </a>
                <button
                  onClick={() => setNumberAction(1)}
                  className={styles.btnNewAccount}
                >
                  Log In
                </button>
              </>
            )}

            {numberAction === 3 && (
              <>
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
                <input
                  placeholder="Confirm password"
                  value={rePassword}
                  onChange={(e) => setRePassword(e.target.value)}
                  type="text"
                  className={styles.loginInput}
                />
                <button
                  onClick={hanldeResetPassword}
                  className={styles.btnNewAccount}
                >
                  Reset Password
                </button>
              </>
            )}
          </Modal>
        </div>
        <hr />
      </div>
    </React.Fragment>
  );
}
