import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserGroup } from "@fortawesome/free-solid-svg-icons";
import styles from "./index.module.scss";

import * as React from "react";

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
  const [friends, setFriends] = React.useState<IUser[]>([]);

  React.useEffect(() => {
    fetch(`https://localhost:7076/api/Users/search?search=${e.target.value}`, {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => {
        return res.json();
      })
      .then((friends) => {
        return setFriends(friends);
      });
  }, []);
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
