import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserGroup } from "@fortawesome/free-solid-svg-icons";
import styles from "./index.module.scss";

import * as React from "react";
import { useEffect, useState } from "react";

export interface ISideRightProps {}

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
export default function SideRight(props: ISideRightProps) {
  const [friends, setFriends] = useState<IUser[]>([]);
  const [user, setUser] = useState<{ userName: string }>();
  const [username, setUserName] = useState<string>("");

  // useEffect(() => {
  //   fetch(`https://localhost:7076/api/Users/friend?username=${username}`)
  //     .then((res) => {
  //       return res.json();
  //     })
  //     .then((friends) => {
  //       return setFriends(friends);
  //     })
  //     .catch((error) => {
  //       console.log(error);
  //     });

  //   const user = localStorage.getItem("user");
  //   if (user) {
  //     setUser(JSON.parse(user));
  //     setUserName(JSON.parse(user)?.userName);
  //   }
  // }, []);

  return (
    <div className={styles.sidebarRight}>
      <div>
        <img src="https://www.w3schools.com/css/paris.jpg" alt="" />
      </div>
      <ul className={styles.friends}>
        <div>
          <div className={styles.avatar}>
            <img src="https://www.w3schools.com/css/paris.jpg" alt="" />
            <div className={styles.active}></div>
          </div>
          <a href="#">Xuan Loi</a>
        </div>
        <div>
          <div className={styles.avatar}>
            <img src="https://www.w3schools.com/css/paris.jpg" alt="" />
            <div className={styles.active}></div>
          </div>
          <a href="#">Xuan Loi</a>
        </div>
        <div>
          <div className={styles.avatar}>
            <img src="https://www.w3schools.com/css/paris.jpg" alt="" />
            <div className={styles.active}></div>
          </div>
          <a href="#">Xuan Loi</a>
        </div>
        <div>
          <div className={styles.avatar}>
            <img src="https://www.w3schools.com/css/paris.jpg" alt="" />
            <div className={styles.active}></div>
          </div>
          <a href="#">Xuan Loi</a>
        </div>
        <div>
          <div className={styles.avatar}>
            <img src="https://www.w3schools.com/css/paris.jpg" alt="" />
            <div className={styles.active}></div>
          </div>
          <a href="#">Xuan Loi</a>
        </div>
      </ul>
    </div>
  );
}
