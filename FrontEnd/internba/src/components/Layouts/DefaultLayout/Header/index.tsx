import * as React from "react";
import { useState, useEffect } from "react";
import styles from "./Header.module.scss";
import ModalLogin from "../../../modal/login";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
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

export default function Header(props: IHeaderProps) {
  const [users, setUsers] = useState<IUser[]>([]);
  const [baseUser, setBaseUser] = useState<IUser[]>([]);
  const [show, setShow] = useState<boolean>(false);

  useEffect(() => {
    fetch("https://localhost:7076/api/Users")
      .then((res) => res.json())
      .then((users) => {
        setUsers(users);
        setBaseUser(users);
      });
  }, []);

  const handleSearchChange = (e: any) => {
    let currentUsers = [...baseUser];
    currentUsers = baseUser.filter((user: IUser) =>
      user.username.includes(e.target.value)
    );
    setUsers(currentUsers);
  };

  return (
    <React.Fragment>
      <div className={styles.Header}>
        <div className={styles.headIcon}>Intern Fetch</div>
        <div className={styles.searchBar}>
          <form action="" className={styles.searchInput}>
            <input onChange={handleSearchChange} className={styles.searchBox} />
            <span></span>
            <button className={styles.searchButton}>
              <FontAwesomeIcon icon={faMagnifyingGlass} />
            </button>
            <ul>
              {users.map((user: IUser) => {
                return <li key={user.id}>{user.username}</li>;
              })}
            </ul>
          </form>
        </div>
        <div className={styles.actButton}>
          <button className={styles.button}>Upload</button>
          <button className={styles.button}>Message</button>
          <button onClick={() => setShow(true)} className={styles.button}>
            Login
          </button>
          <ModalLogin onClose={() => setShow(false)} show={show} />
        </div>
        <hr />
      </div>
    </React.Fragment>
  );
}
