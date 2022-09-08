import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

function Poststyles() {
  interface IComment {
    id: string;
    content: string;
    userId: string;
    postId: string;
  }
  const [comments, setComment] = useState([]);
  useEffect(() => {
    fetch(
      "https://localhost:7076/api/Comments/filter?postID=6466cfab-e4de-498e-b484-08da917899f1"
    )
      .then((response) => response.json())
      .then((comments) => {
        setComment(comments);
        console.log(comments);
      })
      .catch((err) => {
        console.log(err.message);
      });
  }, []);

  return (
    <React.Fragment>
      <div className={styles.commentWrapper}>
        <img
          src="https://lh3.googleusercontent.com/a/AATXAJwKOUIR8zBbhQomf7plXxFDd7K5yJWDBLpYvAMH=s96-c"
          alt=""
        />
        <div>
          <div className={styles.commentBox}>
            <div className={styles.commentTitle}>Huong Lan</div>
            <div className={styles.commentDescription}>Nice</div>
            <div className={`${styles.commentEmotion} ${styles.active}`}>
              <img
                src="https://winka-social-network.netlify.app/static/media/likeCount.5d3594a6.svg"
                alt=""
              />
              <span>7</span>
            </div>
          </div>
          <div className={styles.commentReaction}>
            <span>Like</span>
            <span>Reply</span>
            <span>3 hours ago</span>
          </div>
        </div>
      </div>

      <div className={styles.commentWrapper}>
        <img
          src="https://lh3.googleusercontent.com/a/AATXAJwKOUIR8zBbhQomf7plXxFDd7K5yJWDBLpYvAMH=s96-c"
          alt=""
        />
        <div>
          <div className={styles.commentBox}>
            <div className={styles.commentTitle}>Huong Lan</div>
            <div className={styles.commentDescription}>Nice</div>
            <div className={`${styles.commentEmotion} ${styles.active}`}>
              <img
                src="https://winka-social-network.netlify.app/static/media/likeCount.5d3594a6.svg"
                alt=""
              />
              <span>7</span>
            </div>
          </div>
          <div className={styles.commentReaction}>
            <span>Like</span>
            <span>Reply</span>
            <span>3 hours ago</span>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}
export default Poststyles;
