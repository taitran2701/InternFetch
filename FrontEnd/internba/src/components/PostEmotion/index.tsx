import { count } from "console";
import React from "react";
import styles from "./index.module.scss";

interface IPostEmotion {
  count: number;
}

function PostEmotion() {
  return (
    <React.Fragment>
      <div className={styles.emotion}>
        <span></span>
      </div>
      <div className={styles.comment}>7 comments</div>
    </React.Fragment>
  );
}

export default PostEmotion;
