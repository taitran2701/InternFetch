import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

interface IPost {
  postComment: {
    id: string;
    content: string;
    userId: string;
  };
}

interface IComment {
  id: string;
  content: string;
  userId: string;
  createdDate: Date;
}

function AddComment(props: IPost) {
  const [user, setUserName] = useState<{ userId: string }>();
  const [comments, setComments] = useState([]);
  const [content, setContent] = useState<string>("");
  const [posts, setPosts] = useState([]);
  const [userId, setUserId] = useState<string>("");
  const [postId, setPostId] = useState<string>("");

  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUserId(JSON.parse(user)?.userId);
    }
  });

  const addComment = () => {
    fetch("https://localhost:7076/api/Comments", {
      method: "POST",
      body: JSON.stringify({
        content,
        userId: userId,
        postId: props.postComment.id,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        setComments(data);
        setContent(content);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };
  const handleSubmit = (e: any) => {
    if (e.key === "Enter") {
      addComment();
      setContent("");
    }
  };

  const handleComment = () => {
    fetch(
      `https://localhost:7076/api/Comments/filter?postID=${props.postComment.id}`,
      {
        method: "GET",
        headers: {
          "Content-type": "appication/json;charset=UTF-8",
        },
      }
    )
      .then((response) => response.json())
      .then((comments) => {
        setComments(comments);
        console.log(comments);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  //Delete
  const deleteComment = async (id: string) => {
    await fetch(`https://localhost:7076/api/Comments/${id}`, {
      method: "DELETE",
    }).then((response) => {
      if (response.status === 200) {
        setComments(
          comments.filter((comment: IPost) => {
            return comment.postComment.id !== id;
          })
        );
      } else {
        return;
      }
    });
  };

  // useEffect(() => {
  //   const user = localStorage.getItem("user");
  //   if (user) {
  //     setUserName(JSON.parse(user));
  //     const tenTK = JSON.parse(user)?.userName;
  //     const userId = JSON.parse(user)?.userId;
  //   }
  // }, []);
  return (
    <React.Fragment>
      <div className={styles.feedActionWrapper}>
        <div className={styles.action}>
          <span
            role="img"
            aria-label="like"
            className={`${styles["emotionIcon"]} ${styles["anticon"]}`}
          ></span>
          <span className={styles.emotionTitle}>Like</span>
        </div>
        <div className={styles.action}>
          <span
            role="img"
            aria-label="like"
            className={`${styles["emotionIcon"]} ${styles["anticon"]}`}
          ></span>
          <button onClick={handleComment} className={styles.emotionTitle}>
            Comment
          </button>
        </div>
        <div className={styles.action}>
          <span
            role="img"
            aria-label="like"
            className={`${styles["emotionIcon"]} ${styles["anticon"]}`}
          ></span>
          <span className={styles.emotionTitle}>Share</span>
        </div>
      </div>

      <div className={styles.commentWrapper}>
        <img
          src="https://lh3.googleusercontent.com/a/AATXAJwKOUIR8zBbhQomf7plXxFDd7K5yJWDBLpYvAMH=s96-c"
          alt=""
        />
        <div>
          {comments.map((comment: IComment) => {
            return (
              <React.Fragment>
                <div className={styles.commentBox}>
                  <div className={styles.commentTitle}>{comment.userId}</div>
                  <div className={styles.commentDescription}>
                    {comment.content}
                  </div>
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
                  <button onClick={() => deleteComment(comment.id)}>
                    Delete
                  </button>
                </div>
              </React.Fragment>
            );
          })}
        </div>
      </div>

      {/* AddComment */}
      <input
        onKeyDown={handleSubmit}
        className={styles.commentInput}
        type="text"
        placeholder="Write a public comment "
        value={content}
        onChange={(e) => setContent(e.target.value)}
      />
    </React.Fragment>
  );
}
export default AddComment;
