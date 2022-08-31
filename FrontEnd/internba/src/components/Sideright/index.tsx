import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserGroup } from "@fortawesome/free-solid-svg-icons";
import styles from "./index.module.scss";

import * as React from "react";

export interface ISideRightProps {}

export default function SideRight(props: ISideRightProps) {
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
