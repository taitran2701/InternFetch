import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

interface IPost {
  postComment: {
    id: string;
    content: string;
    userId: string;
  };
}

function AddComment(props: IPost) {
  const [user, setUserName] = useState<{ userId: string }>();
  const [comments, setCommments] = useState<string>("");
  const [content, setContent] = useState<string>("");
  const [posts, setPosts] = useState([]);
  const [userId, setUserId] = useState<string>("");

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
        setCommments(data);
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
