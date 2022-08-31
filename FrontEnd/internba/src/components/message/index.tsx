import * as React from "react";
import styles from "./index.module.scss";
export interface IMessageProps {}

export default function Message(props: IMessageProps) {
  return (
    <div className={styles.dropdown}>
      <button className={styles.dropdownBtn}>Message</button>
      <div className={styles.dropdownContent}>
        <input placeholder="Enter name" />
        <a href="#">
          <div className={styles.avatar}>abc</div>
          <div className="chatInfo">
            <p className={styles.username}>Xuan Loi</p>
            <p className={styles.content}>Hihi</p>
          </div>
        </a>
      </div>
    </div>
  );
}
